using Fezitor.Interface.Model;
using Fezitor.Interface.View;
using Fezitor.Model;
using Fezitor.Presenter;
using Fezitor.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fezitor.Test.Mock
{
    class MockPresenter// : IPresenter
    {
        public void Run(IModel<FezitorSettings> model, IView<FezitorSettings> view)
        {
            throw new NotImplementedException();
        }
    }
}
