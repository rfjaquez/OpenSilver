

/*===================================================================================
* 
*   Copyright (c) Userware/OpenSilver.net
*      
*   This file is part of the OpenSilver Runtime (https://opensilver.net), which is
*   licensed under the MIT license: https://opensource.org/licenses/MIT
*   
*   As stated in the MIT license, "the above copyright notice and this permission
*   notice shall be included in all copies or substantial portions of the Software."
*  
\*====================================================================================*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DotNetForHtml5.EmulatorWithoutJavascript
{
    class StaticConstructorsCaller
    {
        public static void EnsureStaticConstructorOfCommonTypesIsCalled(Assembly coreAssembly)
        {
            // This is useful to ensure that the "Type Converters" defined in common types are registered prior to executing the app.
            // This is not needed when running the compiled JavaScript code because static constructors are always called before anything else.

            LoadTypeConstructor("Windows.Foundation", "System.Windows", "Point", coreAssembly);
            LoadTypeConstructor("Windows.Foundation", "System.Windows", "Size", coreAssembly);
            LoadTypeConstructor("Windows.UI", "System.Windows.Media", "Color", coreAssembly);
            LoadTypeConstructor("Windows.UI.Text", "System.Windows", "FontWeight", coreAssembly);
            LoadTypeConstructor("Windows.UI.Xaml", "System.Windows", "Thickness", coreAssembly);
            LoadTypeConstructor("Windows.UI.Xaml", "System.Windows", "CornerRadius", coreAssembly);
            LoadTypeConstructor("Windows.UI.Xaml", "System.Windows", "Duration", coreAssembly);
            LoadTypeConstructor("Windows.UI.Xaml", "System.Windows", "GridLength", coreAssembly);
            LoadTypeConstructor("Windows.UI.Xaml.Media.Animation", "System.Windows.Media.Animation", "KeyTime", coreAssembly);
            LoadTypeConstructor("Windows.UI.Xaml.Media.Animation", "System.Windows.Media.Animation", "RepeatBehavior", coreAssembly);
            LoadTypeConstructor("Windows.UI.Xaml.Media", "System.Windows.Media", "Brush", coreAssembly);
            LoadTypeConstructor("Windows.UI.Xaml.Media", "System.Windows.Media", "DoubleCollection", coreAssembly);
            LoadTypeConstructor("Windows.UI.Xaml.Media", "System.Windows.Media", "FontFamily", coreAssembly);
            LoadTypeConstructor("Windows.UI.Xaml.Media", "System.Windows.Media", "Geometry", coreAssembly);
            LoadTypeConstructor("Windows.UI.Xaml.Media", "System.Windows.Media", "PointCollection", coreAssembly);
            LoadTypeConstructor("Windows.UI.Xaml.Media", "System.Windows.Media", "ImageSource", coreAssembly);
            LoadTypeConstructor("Windows.UI.Xaml.Media", "System.Windows.Media", "Matrix", coreAssembly);
            LoadTypeConstructor("Windows.UI.Xaml", "System.Windows", "PropertyPath", coreAssembly);
#if CSHTML5
            LoadTypeConstructor("Windows.UI.Xaml.Controls", "System.Windows.Controls", "DataGridLength", coreAssembly);
#endif
            LoadTypeConstructor("System.Windows.Input", null, "Cursor", coreAssembly);
        }

        static void LoadTypeConstructor(string typeNamespace, string typeAlternativeNamespaceOrNull, string typeName, Assembly assembly)
        {
            // Note: an "alternative namespace" can be specified in order to be compatible with the "SLMigration" version of the core assembly.

            Type type = assembly.GetType(typeNamespace + "." + typeName);
            if (type == null && !string.IsNullOrEmpty(typeAlternativeNamespaceOrNull))
                type = assembly.GetType(typeAlternativeNamespaceOrNull + "." + typeName);
            if (type == null)
                throw new Exception(string.Format(@"Unable to call the static constructor of the type '{0}' because the type was not found.", typeName));
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(type.TypeHandle);
        }
    }
}
