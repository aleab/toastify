﻿using Toastify.Core;
using Toastify.View;
using ToastifyAPI.Events;

namespace Toastify.Model
{
    /// <summary>
    ///     This action shows or hides Toastify's toast.
    /// </summary>
    public sealed class ToastifyShowToast : ToastifyAction
    {
        #region Public Properties

        /// <inheritdoc />
        public override string Name
        {
            get { return "Show Toast"; }
        }

        /// <inheritdoc />
        public override ToastifyActionEnum ToastifyActionEnum
        {
            get { return ToastifyActionEnum.ShowToast; }
        }

        public bool ShouldPrintExtendedDebugLog { get; set; }

        #endregion

        /// <inheritdoc />
        public override void PerformAction()
        {
            if (ToastView.Current?.IsInitComplete == true)
            {
                if (this.ShouldPrintExtendedDebugLog)
                    ToastView.Current.PrintInternalDebugInfo();

                ToastView.Current.Toggle(true);
                this.RaiseActionPerformed(this);
            }
            else
                this.RaiseActionFailed(this, new ActionFailedEventArgs("ToastView is not ready."));
        }
    }
}