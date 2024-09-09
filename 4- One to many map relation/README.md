[Atras - EFCore](https://github.com/IngSoft-DA2/DA2-Tecnologia/tree/ef-core)
# Configuracion relacion 1 a N

Para realizar esta configuracion es necesario guardar en la entidad primaria (`User`) un estado de tipo coleccion como `List` del tipo de entidad secundaria (`Book`). Quedando la clase `User` de la siguiente manera:
```C#
public sealed record class User()
{
    // ...

    public List<Book> Books { get; init; } = [];

    //...
}
```
Dicho estado es inicializado para asegurarnos que siempre tenga un valor, aunque sea una lista vacia. De esta forma nos evitamos estar preguntando si la coleccion es `null` constantemente. Tambien estariamos realizando la buena practica de nunca retornar null cuando se tiene que retornar una coleccion, el valor por defecto de este tipo debemos asegurarnos de que sea una coleccion vacia.

Luego en la entidad secundaria tenemos que configurar la FK a la entidad primaria de la siguiente manera:
```C#
public sealed record class Book()
{
    // ...
    public Guid AuthorId { get; init; }

    public User Author { get; init; } = null!;
    // ...
}
```
En esta entidad estamos configurando que la columna con la constraint `FK` se llame `AuthorId` no dejando la opcion de que `EFCore` genere el nombre automaticamente. Con esta configuracion tenemos mas control sobre el modelado de tablas en la base de datos, es una relacion uno a uno y podemos evolucionar y mantener dicho esquema con mayor facilidad. Tambien trae la ventaja de tener cierta flexibilidad en la manipulacion de los datos pudiendo ser mas performantes y optimos en el armado de las queries.

Otra cosa a notar es que la property `AuthorId` no tiene configurado de que sea requerido, esto es porque el tipo `Guid` es un `struct` por lo que asegura de que no se le pueda asociar un valor `null`, esta configuracion se le pone a la property que identifica la relacion, la cual es `Author`. Tambien con esta configuracion estamos eligiendo el nombre del rol de como estas dos entidades se ven entre ellas, logrando mas transparencia y similitud con lo encontrado en la base de datos.
