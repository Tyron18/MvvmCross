using System;
using System.Reflection;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.Content;
using Android.Widget;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;
using MvvmCross.Platform.Exceptions;
using MvvmCross.Platform.Platform;

namespace MvvmCross.Binding.Droid.Target
{
    public class MvxAppCompatTextViewColorIdBinding
       : MvxConvertingTargetBinding<TextView, int>
    {
        public MvxAppCompatTextViewColorIdBinding(TextView target) : base(target)
        {
        }

        public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;

        protected override void SetValueImpl(TextView target, int value)
        {
            try
            {
                var context = target.Context;
                Color color;
                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                    color = new Color(context.Resources.GetColor(value, context.Theme));
                else
#pragma warning disable CS0618 // Type or member is obsolete
                    color = new Color(context.Resources.GetColor(value));
#pragma warning restore CS0618 // Type or member is obsolete

                target.SetTextColor(color);
            }
            catch (Exception ex)
            {
                MvxTrace.Error(ex.ToLongString());
                throw;
            }
        }
    }
}