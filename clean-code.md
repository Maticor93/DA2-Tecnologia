# Tips Clean Code

Clean code es codigo que:

- Facil de leer
- Facil de mantener
- Facil de entender

Escribir clean code es una habilidad la cual se puede aprender.

## 1. Remplazar condiciones de if complejas por metodos descriptivos

Las condiciones complejas dentro de un if complejisan la lectura y el entendimiento de la condicion, cuanto mas condiciones abarca, mas dificil es de interpretar y de mantener.

La solucion es mover la condicion a un metodo o variable con un nombre descriptivo. El nombre debe de ser lo mas detallado posible.

Esta practiva una mejora significante en la lectura del codigo.

<p align="center">
<img src="./images/image.png">
</p>

<p align="center">
[If statement -> Method]
</p>

## 2. Juntar varias condiciones de ifs en uno

La idea principal es evitar muchos ifs anidados los culaes abren siempre caminos logicos. Lo ideal seria agruparlos en una unica condicion.

<p align="center">
<img src="./images/image-2.png">
</p>

<p align="center">
[Merge condiciones de ifs]
</p>

## 3. Usar nameof para convertir enum a string

La palabra clave `nameof` introducido en C# 6.0, es usado para obtener el nombre de una variable, tipo como string en tiempo de compilacion. Es util para evitar strings magicos en el codigo y mantener el codigo mas refactor-friendly.

`nameof` es la forma preferible para convertir un enum a string. Esto es porque `nameof` es evaluado en tiempo de compilacion y va a inyectar un string que nunca va a cambiar, mientras que el metodo `ToString` es evaluado en tiempo de ejecucion. Esto significa que `nameof` es mas eficiente y puede mejorar la performance del codigo.

<p align="center">
<img src="./images/image-3.png">
<p>

<p align="center">
[Nameof en vez de ToString]
</p>

## 4. Mapear una Request a una entidad

Es logico pensar que la request deberia de contener un metodo para pasarse a si mismo a otra estructura si pensamos en principios como encapsulamiento y SRP.

Algunos ventajas son:

- El mapeo de Request a otra entidad esta encapsulado
- Los controllers son mas limpios porque el mapeo esta en otro lado

Solo se tiene que hacer la llamada al metodo y se obtendra una entidad relevante.

```C#
public sealed record class CreateMovieRequest
{
  public string? Title  { get; init; }

  public string? Description { get; init; }

  public CreateMovieArgs Map()
  {
    return new CreateMovieArgs(
      Title,
      Description
    )
  }
}
```

```C#
[HttpPost]
public void Create(CreateMovieRequest request)
{
  var args = request.Map();
}
```

## 5. Evitar muchos argumentos en un metodo

Es una buena practica limitar el numero de argumentos en una funcion a dos. Si una funcion requiere mas de dos argumentos significa que esa funcion esta haciendo mucho mas de lo esperado y deberia de ser refactoriado.

Podemos refactorear la funcion usando un **struct** o un **record** para encapsular los parametros relacionados en vez de pasarlos de forma individual.

Las ventajas de esta practica son:

- Se mejora la lectura del codigo
- Es mas facil de mantener
- Simplifica las pruebas
- El codigo es mas flexible

Evitar muchos argumentos en una funcion es una practica importante para escribir codigo limpio y mantenible. Al usar objetos que encapsulan la data, podemos simplificar la firma de la funcion y hacer que el codigo sea mas leible y facil de testear.

<p align="center">
<img src="./images/image-4.png">
<p>

<p align="center">
[Agrupacion muchos argumentos]
</p>

## 6. Clausulas Guard

Una clausula guard prevee la completitud de una funcion al chequear valores invalidos.

Las clausulas guard mejoran la lectura y mantenibilidad del codigo. Nos permiten manejar las excepciones de forma mas segmantica.

Tambien ayudan a implementar la metodologia Fail-fast.

Una ventaja de estas clausulas es que minimizan codigo anidado y lo hace mas detallado.

Algunos buenos casos donde usarlo son:

- Validaciones de entrada
- Comprobacion de condiciones
- Comprobacion de null

<p align="center">
<img src="./images/image-5.png">
<p>

<p align="center">
[Guard clause]
</p>

## 7. MinBy y MaxBy

Antes de .NET 6 para obtener el minimo o el maximo, se tenia que hacer en dos pasos, ordenar la coleccion de forma ascendente o descendente y obtener el primer elemento.

Pero en .NET 6 se tiene las funciones linq MinBy y MaxBy.

<p align="center">
<img src="./images/image-6.png">
<p>

<p align="center">
[MinBy MaxBy]
</p>

## 7. LINQ en vertical no en horizontal

Escribir la concatenacion de funciones LINQ se deben de escribir de forma vertial para mejorar la lectura y hacer mas facil el entendimiento de los mismos.

Concatenar las funciones LINQ de forma horizontal dificulta en la lectura, la extension y mantenibilidad.

<p align="center">
<img src="./images/image-7.png">
<p>

<p align="center">
[Concatenacion de forma horizontal]
</p>
<p align="center">
<img src="./images/image-6.png">
<p>

<p align="center">
[Concatenacion de forma vertical]
</p>

## 8. Convencion de nombres de properties
A continuacion se muestra cual es la convencion en C# para nombrar properties segun la visibilidad de las mismas:
- Properties `public` tienen que seguir `PascalCase` -> `public string Name { get; set; }`
- Properties `private` y `protected` tienen que seguir `_camelCase` -> `private string _name { get; set; }`

## 9. Convencion de nombre de argumentos de una funcion
Por convencion en C# los argumentos tienen que seguir `camelCase`
```C#
public void MyFunction(string myArgument)
{
  // some logic
}
```

## 10. Convencion de nombre de clase
Por convencion en C# los nombres de las clases tienen que seguir `PascalCase`
```C#
public class MyClass
{
  // some code of class
}
```

## 11. Convencion de nombre de proyectos
Por convencion en C# los nombres de los proyectos tienen que seguir `PascalCase`. Es buena practica tambien poner como subfijo al nombre del proyecto el contexto/negocio en el cual esta situado. Esto ayuda a los desarrolladores entender la responsabilidad de dicho paquete dentro de la solucion.

Por ejemplo, si se esta trabajando en una solucion llamada `Vidly` y se tiene el proyecto para la web api, el mismo se llamaria: `Vidly.WebApi`, siendo la primera parte el contexto y la segunda el tipo de proyecto que es.

## 12. Hacer uso de LINQ para mapear
LINQ (Language Integrated Query) proporciona una sintaxis uniforme para consultar y manipular colecciones de datos. Si uno desea convertir una coleccion de datos a otra coleccion de datos, la forma mas practica es utilizando la funcion `ConvertAll` de LINQ.

```C#
// FORMA INCORRECTA
var responses = new List<Response>();
foreach(var entity in entities){
  var response = new Response(entity);
  responses.Add(response);
}
```
<p align="center">
  [Iteracion manual]
</p>

```C#
// FORMA CORRECTA
entities.ConvertAll(e => new Response(e));
```
<p align="center">
  [Iteracion con LINQ]
</p>

## 12. De string a DateTimeOffset
Cuando se desea convertir un string a un tipo de fecha (DateTimeOffset, DateTime, DateOnly, TimeOnly) es buena practica configurar el parseo indicando como debe ser el formato de esa fecha en string, la cultura a tener en cuenta, entre otros parametros. Es importante especificar estas configuraciones ya que por defecto los metodos `Parse` o `TryParse` configuraran estos aspectos tomando los valores del sistema operativo, lo cual puede causar comportamientos inesperados.

Por ejemplo si nuestra maquina usa el formato `dd-MM-yyyy`, tomara este formato como defecto para realizar la conversion. El codigo en esa maquina funcionara correctamente, pero solo funciona en ese ambiente, si ejecutamos el codigo en otra maquina donde el formato de la fecha es `MM-dd-yyyy` el codigo se comportara de forma diferente causando inconsistencias.

```C#
using System;

public DateTime Parse(string possibleDate)
{
  var isNotParsed = !DateTime.TryParse(possibleDate, out DateTime dateParsed);

  if(isNotParsed)
  {
    throw new ArgumentException("Parameter possibleDate is not a valid date");
  }

  return dateParsed;
}
```
<p align="center">
  [Evitar]
</p>

```C#
using System;
using System.Globalization;

public DateTime Parse(string possibleDate)
{
  var isNotParsed = !DateTime.TryParseExact(
    possibleDate,
    "dd-MM-yyyy",
    CultureInfo.InvariantCulture,
    DateTimeStyles.None,
    out DateTime dateParsed);

  if(isNotParsed)
  {
    throw new ArgumentException("Parameter possibleDate is not a valid date");
  }

  return dateParsed;
}
```
<p align="center">
  [Implementar]
</p>

## 13. No ser fuertemente tipado con string ('Stringly' typed)

Ser fuertemente tipado significa aplicar reglas de tipo mas estrictas para garantizar que los tipos de datos sean correctos y coherentes en toda la aplicacion.

El uso de enums en vez de strings es una practica comun para promoveer un codigo en C# fuertemente tipado.

Dado que:
1. Mejora la claridad y seguridad del codigo
2. Hay un chequeo en tiempo de compilacion
3. Nos ayuda IntelliSense y completitud automatica
4. Performance
5. Mas facil de mantener

Asi como se puede usar enums, se pueden usar clases staticas propias para preservar el valor en string si se desea.

```C#
public void DontDoThis(string employeeType)
{
  if(employeeType == "administrator")
  {
    // do something
  }
}
```
<p align="center">
  [Codigo stingly typed]
</p>

```C#
public void DoThis(Employee employee)
{
  if(employee.Type == Type.Administrator)
  {
    // do something
  }
}
```
<p align="center">
  [Codigo strongly typed]
</p>
