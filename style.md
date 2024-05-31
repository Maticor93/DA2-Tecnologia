[Atras - Indice](https://github.com/daniel18acevedo/DA2-Tecnologia/blob/angular/angular-style)

# Estilos

Los estilos en una aplicacion son muy importantes porque son los que terminan captando al usuario de seguir usando la aplicacion en conjunto a buenas practicas de experiencia de usuario.

Es por esto que la combinacion de practicas UX/UI (experiencia de usuario e interfaz de usuario) son criticas para la captacion y mantenimiento de los usuarios en la plataforma.

Hay varias formas de implementar estilos a nuestras pantallas, las mas populares son:

- Angular Material

- Bootstrap

- Custom

Cada una de ellas presenta sus ventajas y desventajas, las cuales seran discutidas en su seccion.

La seleccion de que herramienta utilizar para la implementacion de estilado es una decision importante que no debe tomarse a la ligera. Esta decision tiene un impacto grande en nuestra aplicacion ya que la herramienta sera usada en toda la aplicacion. Es por eso que el intentar la de cambiar la herramienta por una mala decision, conlleva un esfuerzo muy grande de realizar.

Es por eso que el uso de la herramienta debe estar lo mayor encapsulado posible. Para lograr esto debemos de crear componentes sumamente concretos como esqueletos que seran los que usen la herramienta de diseño y otros componentes mas concretos que usen estos componentes esqueletos.

De esta forma logramos encapsular el impacto de cambio de la herramienta en algunos componentes clave y no en toda la aplicacion.

Aquellos componentes esqueletos son aquellos componentes genericos que no estan arraigados a al negocio, por ejemplo: `button`, `input`, `dropdown`, `modal`, `image`, etc. Estos componentes son los que deben utilizar la herramienta de estilado para que otros componentes dentro de la aplicacion no tengan la dependencia a la herramienta, sino que a estos componentes.

Tambien es muy comun encapsular distintas configuraciones de estos elementos en elementos nuevos para evitar la duplicacion. Por ejemplo podriamos tener dos variaciones `primary-button` y `secondary-button` del componente `button` que encapsulan distintas configuraciones de este componente.

Por ejemplo en `button` un input que sea `color` para pasarle el valor del color que queramos que tenga el boton, podrimos tener en `primary-button` lo siguiente:

```HTML
<app-button color="blue"/>
```

Para que luego en la aplicacion usemos:

```HTML
<app-primary-button/>
```

Logrando reutilizar la encapsulacion de la configuracion del componente `button` como `primary` en el componente `primary-button`. De esta manera si el dia de mañana la forma de renderizar `primary-button` esta encapsulado en un componente y no desplegado en muchas partes de la aplicacion.

