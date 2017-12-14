using System;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using MvvmCross.Binding.Bindings.Target;
using MvvmCross.Platform.Exceptions;
using MvvmCross.Platform.Platform;

namespace MvvmCross.Binding.Droid.Target
{
    public class MvxAppCompatViewBackgroundColorIdBinding
       : MvxConvertingTargetBinding<View, int>
    {
        public MvxAppCompatViewBackgroundColorIdBinding(View target) : base(target)
        {
        }

        public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;

        protected override void SetValueImpl(View target, int value)
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

                target.Background = new ColorDrawable(color);
            }
            catch (Exception ex)
            {
                MvxTrace.Error(ex.ToLongString());
                throw;
            }
        }
    }
}