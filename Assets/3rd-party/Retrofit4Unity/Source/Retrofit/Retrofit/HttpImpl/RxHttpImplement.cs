#region License
// Author: Weichao Wang     
// Start Date: 2017-05-22
#endregion

using UniRx;

namespace Retrofit.HttpImpl
{
    public interface IRxHttpImplement:HttpImplement
    {
        void RxSendRequest<T>(IObserver<T> o, Converter.Converter convert, object request);
        object RxBuildRequest<T>(IObserver<T> o, Converter.Converter convert, RestMethodInfo methodInfo, string url);
        void Cancel(object request);
    }
}