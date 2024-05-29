[Atras - Indice](https://github.com/daniel18acevedo/DA2-Tecnologia/tree/angular-navigation)

# Navegacion con parametros

Es comun querer pasar informacion en la ruta de navegacion. Por ejemplo, si consideramos una aplicacion que muestra un listado de elementos y cada elemento tiene un unico `id`. Para editar un elemento determinado, el usuario haria click en un boton `Editar`, que navegaria el usuario a la vista del componente `UpdateElementComponent`.

Para hacer definimos la ruta de la siguiente forma:

```TypeScript
export const appRoutes: Route[] = [
  {
    path:'elements/:elementId'
    component: UpdateElementComponent
  }
]
```

Y en el componente declaramos un parametro que matchee en nombre y usar `Input`

```TypeScript
@Input()
set id(elementId: string) {
  this.element$ = this.service.getElementById(elementId);
}
```

En caso de querer hacer uso de dicho parametro al momento de inicializacion del componente:

```TypeScript
ngOnInit() {
  const id = this.route.snapshot.paramMap.get('elementId')!;

  this.element$ = this.service.getElementById(id);
}
```

## Codigos

- [Codigo de ejemplo de navegacion con parametros](https://github.com/daniel18acevedo/DA2-Tecnologia/tree/angular-navigation/1-%20Angular%20application/MyNavigationWithParamsExampleApp)

