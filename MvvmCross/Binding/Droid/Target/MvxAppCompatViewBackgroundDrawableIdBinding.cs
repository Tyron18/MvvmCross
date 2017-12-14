using System;
using Android.OS;
using Android.Views;
using MvvmCross.Binding.Bindings.Target;
using MvvmCross.Platform.Exceptions;
using MvvmCross.Platform.Platform;

namespace MvvmCross.Binding.Droid.Target
{
    public class MvxAppCompatViewBackgroundDrawableIdBinding
       : MvxConvertingTargetBinding<View, int>
    {
        public MvxAppCompatViewBackgroundDrawableIdBinding(View target) : base(target)
        {
        }

        public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;

        protected override void SetValueImpl(View target, int value)
        {
            try
            {
                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                    target.Background = target.Context?.Resources?.GetDrawable(value, target.Context.Theme);
                else
#pragma warning disable CS0618 // Type or member is obsolete
                    target.Background = target.Context?.Resources?.GetDrawable(value);
#pragma warning restore CS0618 // Type or member is obsolete
            }
            catch (Exception ex)
            {
                MvxTrace.Error(ex.ToLongString());
                throw;
            }
        }
    }
}