using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Imdb.Helpers
{
    public class BasePage : Page
    {
        public virtual string Header => "";
    }
}
