# Configuracino de repo

A continuacion se pueden encontrar aquellos archivos que son requeridos en la solucion junto con una descripcion de cuales son los objetivos.

## Archivos

- **.gitignore**: Este archivo es necesario y requerido para ignorar aquellos archivos que no se quiere tener un control de version. Esto quiere decir, que ciertos archivos por mas que sean modificados, eliminados o agregados, no se vera ningun cambio efectuado en el historico de cambios de git antes al momento de crear un commit. Para que este archivo tenga efecto, tiene que ser commiteado en un primer commit antes de ponerse a trabajar en el proyecto.

- **.editorconfig**: Es un archivo que configura reglas de clean code para c#. En caso de que este archivo genere problemas al momento de compilar, ejecutar o tengan contradicciones.

- **Directory.Build.props**: Es el lugar para especificar aquellos paquetes que son usados por todos los proyectos locales de la solucion. Es una forma mas rapida de controlar sus versiones y que los paquetes locales se actualicen en simultaneo.

- **pull_request_template.md**: Es una guia sobre la informacion a incluir en los pull request que se creen.

- **.github/workflows/build-and-test.yml**: es una configuracion para ejecutar tareas al momento de realizar ciertas acciones en github. Esta configurado para que haga build y corra las pruebas junto con el chequeo de cobertura del codigo, cuando se crea un pull request y cuando se mergea codigo a una rama.

- **.github/workflows/code-analysis**: es una configuracion que analisa el codigo en funcion a los parametros del archivo **.editorconfig**.

# Badges

Las badges que se van agregar son indicadores del estado en el que se encuentra nuestro proyecto.

```md
[![Build and Test](https://github.com/daniel18acevedo/style-analysis/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/daniel18acevedo/style-analysis/actions/workflows/build-and-test.yml)
```

Se deberan de adecuar las rutas acorde a sus repositorios.

# Configuracion de branches

Se requiere que configuren reglas en las branches principales para evitar conflictos al momento de mergear.

- Ir a Settings (Ultima opcion en la barra de navegacion en github en el repositorio)
<p align="center">
<img src="images/image-1.png"/>
</p>

## General

- Ir a General
<p align="center">
<img src="images/image-10.png"/>
</p>

- La branch por defecto debera ser `develop`
<p align="center">
<img src="images/image-7.png"/>
</p>

- Configurar la seccion de `Pull Requests` de la siguiente manera
<p align="center">
<img src="images/image-8.png"/>
</p>

## Branches

- Ir a Branches
<p align="center">
<img src="images/image-2.png"/>
</p>

- Crear una nueva regla
<p align="center">
<img src="images/image-3.png"/>
</p>

- En el nombre de la rama poner: `main`

- Seleccionar la opcion `Require a pull request before merging`
<p align="center">
<img src="images/image-4.png"/>
</p>

- Seleccionar `Require status checks to pass before merging` y poner `Build`, `Test` y `Analysis`
<p align="center">
<img src="images/image-5.png"/>
</p>

- Seleccionar `Lock branch`
<p align="center">
<img src="images/image-6.png"/>
</p>

- Para terminar apretar `Create`

- Replicar lo mismo para otra branch llamada `develop`
