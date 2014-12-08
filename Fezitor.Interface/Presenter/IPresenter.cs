using Fezitor.Interface.Model;
using Fezitor.Interface.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fezitor.Interface.Presenter
{
    public interface IPresenter<S>
    {
        void Run(IModel<S> model, IView<S> view);
    }
}
