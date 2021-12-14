using System;
using System.Collections.Generic;
using System.Runtime;
using Smartway.UiComponent.Inputs;
using Xamarin.Forms;

namespace Smartway.UiComponent.Behaviors
{
    public class GroupedItemsBehavior : Behavior
    {
        private static readonly Dictionary<string, List<ISelectableInput>> GroupedItems
            = new Dictionary<string, List<ISelectableInput>>();

        public static readonly BindableProperty GroupNameProperty = BindableProperty.CreateAttached(nameof(GroupName),
            typeof(string), typeof(GroupedItemsBehavior), string.Empty, propertyChanged: GroupNameChanged);

        private static void GroupNameChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var groupName = (string)newvalue;

            if (!GroupedItems.ContainsKey(groupName))
                GroupedItems.Add(groupName, new List<ISelectableInput>());

            GroupedItems[groupName].Add(bindable as ISelectableInput);
        }

        public static string GetGroupName(BindableObject bindable)
        {
            return (string)bindable.GetValue(GroupNameProperty);
        }

        public static void SetGroupName(BindableObject bindable, string value)
        {
            bindable.SetValue(GroupNameProperty, value);
        }

        private string GroupName => GetGroupName(BoundObject);

        private BindableObject BoundObject { get; set; }

        protected override void OnAttachedTo(BindableObject bindable)
        {
            if (!(bindable is ISelectableInput input))
                throw new ArgumentException("GroupedItemsBehavior must be attached to a ISelectableInput.");

            base.OnAttachedTo(bindable);

            BoundObject = bindable;
            input.OnSelected += OnItemSelectionRequested;
        }

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            if (!(bindable is ISelectableInput input))
                throw new ArgumentException("GroupedItemsBehavior must be attached to a ISelectableInput.");

            base.OnDetachingFrom(bindable);

            BoundObject = null;
            input.OnSelected -= OnItemSelectionRequested;
        }

        private void OnItemSelectionRequested(object sender, EventArgs e)
        {
            if (GroupName == string.Empty)
                throw new AmbiguousImplementationException("GroupedItemsBehavior must have a name to work");

            foreach (var item in GroupedItems[GroupName])
                item.IsSelected = item == sender;
        }
    }
}
