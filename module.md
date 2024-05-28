
# Modulos

Las aplicaciones en Angular son modulares y Angular tiene su propio sistema modular llamado NgModules.

Los modulos son contenedores clases cohesivos que responden a una misma porcion de dominio, flujo de trabajo, o un set de funcionalidades relacionadas. Pueden contener componentes, servicios, y otros archivos cuyo scope esta definido por el NgModule. Se pueden importar funcionalidades que son exportadas por otros NgModules, y exportar funcionalidades especificas para ser usadas por otro NgModule.

Una aplicacion pequeña puede operar teniendo definido un unico NgModule, pero lo ideal y lo esperado es tener varios modulos con funcionalidades especificas. El modulo inicial es el root y como indica el nombre, es la raiz que incluira modulos secundarios en una jerarquia de profundidad.

Un modulo esta definido en una clase con el [decorador](https://www.typescriptlang.org/docs/handbook/decorators.html) @NgModule().

Este decorador es una funcion donde los parametros son la descripcion de dicho modulo.

Los parametros mas importantes son:

| Parametro    | Detalles                                                                                                                                                                                       |
| ------------ | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| declarations | Los componentes, directivas, y pipes que pertenecen al modulo                                                                                                                                  |
| imports      | Otros modulos que exportan clases que son necesarios por otros componentes declarados en el modulo                                                                                             |
| exports      | Un subset de declaraciones que tienen que ser visibles y usables por algun componente declarado en otro modulo                                                                                 |
| providers    | Los servicios declarados en este modulo para que sean usados de forma global en la coleccion de servicios. Estos servicios se vuelven accesibles en cualquier parte de la aplicacion           |
| bootstrap    | La vista principal de la aplicacion, se tiene que llamar al componente raiz, que es el que guarda todas las vistas de la aplicacion. Solamente el modulo raiz deberia de definir esta property |

Tenemos el siguiente modulo a modo de ejemplo:

```TypeScript
@NgModule({
  imports:      [ UserModule ],
  providers:    [ MovieService, ],
  declarations: [ HomeMoviePage, MovieFeedComponent, CreateMovieComponent ],
  exports:      [ HomeMoviePage ],
  bootstrap:    []
})
export class MovieModule { }
```

Los modulos proveen un contexto de compilacion a los componentes que declara, y este es compartido entre ellos. Todos los modulos pueden incluir cualquier cantidad de componentes adicionales, los cuales pueden ser cargados a traves del router o creados en un template.

## NgModules vs JavaScript modulos

Los modulos de angular son diferentes a los modulos definidos en JavaScript (ES2015). Los modulos de JavaScript son complementarios que se utiliza para desarrollar la aplicacion.

En JavaScript cada archivo es un modulo y todos los objetos definidos en el archivo pertenece a ese modulo. El modulo declara algunos objetos public al usar la palabra reservada `export`. Una vez marcado aquellos elementos como publicos, otros modulos de JavaScript pueden usar la palabra clave `import` para importar dichos elementos publicos de un modulo en particular.

Por ejemplo:

```TypeScript
import { NgModule } from '@angular/core';
import { UserModule } from 'userModule-location';
```

Aca se puede observar como se importan los elementos exportados `NgModule` y `UserModule` de sus modulos.

## Lecturas recomendadas

- [Modularidad](https://v17.angular.io/guide/ngmodules)