# Estructura

## assets

Dentro de este directorio est�n las referencias generales al CSS y Javascript utilizado por la web.

Hay librer�as Javascript y CSS externas, Bootstrap, Inputmask, que no fueron agregadas mediante NuGet u otro gestor de paquetes, as� como librer�as custom.

Archivos con Javascript custom son: ajax.helpers.js, funciones.js, Inicio.js, validaci�n.js, llamadasJavascript.js.

Posiblemente se pueda restructurar para mejorar el mantimiento.

## Scripts

Est�n las librer�as Javascript y CSS asociado incorporado mediante paquete NuGet. Como jQuery, jQuery Validation y Unobtrusive Validation jQuery.

Esta �ltima es usada por Razor para generar validaciones de campos y el env�o de formularios mediante AJAX.

Las librer�as ah� referenciadas se incluyen la p�gina como Bundles.

M�s informaci�n que puede ser de utilidad:

[Bundling and Minification | Microsoft Docs] (https://docs.microsoft.com/en-us/aspnet/mvc/overview/performance/bundling-and-minification)
[Validating User Input | Microsoft Docs](https://docs.microsoft.com/en-us/aspnet/web-pages/overview/ui-layouts-and-themes/validating-user-input-in-aspnet-web-pages-sites)
[Html.BeginForm() vs Ajax.BeginForm() in MVC3] (https://www.codeproject.com/Articles/429164/Html-BeginForm-vs-Ajax-BeginForm-in-MVC) - conceptualmente sirve para MVC3 o superior.

## Views

### Views\Shared\_Layout.cshtml

Contiene la estructura (layout) principal de la p�gina. 
Tambien las inclusiones de CSS y Javascript.

### Vistas parciales

Las vistas parciales se cargan mediante `@RenderBody()`, el cual se utiliza en _Layout.cshtml.

El target Id para cargar una vista parcial mediante AJAX es viewContent, el cual encierra el `@RenderBody()` del layout principal.

M�s informaci�n en: [Partial Views | Microsoft Docs] (https://docs.microsoft.com/en-us/aspnet/core/mvc/views/partial)

Cambios
