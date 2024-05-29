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

Y el componente lo implementamos de la siguiente manera:

```TypeScript
export class ElementComponent implements OnInit, OnDestroy {
  public parameter: string = '';
  private _paramsSubscription: Subscription | null = null;

  constructor(private route: ActivatedRoute) {}

  ngOnDestroy(): void {
    this._paramsSubscription?.unsubscribe();
  }

  ngOnInit(): void {
    this._paramsSubscription = this.route.params.subscribe((params) => {
      this.parameter = params['elementId'];
    });
  }
}
```

Lo que ocurrira es que el componente sera inicializado por Angular inyectandole un servicio de Angular mismo para acceder a los parametros de las rutas. Dicho servicio lo utilizamos en el metodo del ciclo de vida `OnInit` el cual sera ejecutado una vez cuando el componente este renderizado y listo para cargar data. En este metodo nos suscribiremos a los parametros para escuchar los cambios de los mismos y actualizar el estado del componente a medida que cambia.

Dado que hacemos uso de una suscripcion, para evitar problemas de performance como perdida de memoria, es necesario guardar dicha suscripcion para cuando se destruya el componente se borre la suscripcion en caso de que exista una. Para eso se implementa el metodo del ciclo de vida `OnDestroy`.

## Codigos

- [Codigo de ejemplo de navegacion con parametros](https://github.com/daniel18acevedo/DA2-Tecnologia/tree/angular-navigation/1-%20Angular%20application/MyNavigationWithParamsExampleApp)

