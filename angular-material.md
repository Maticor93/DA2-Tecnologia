[Atras - Indice](https://github.com/daniel18acevedo/DA2-Tecnologia/tree/angular-style)

# Angular Material

Angular Material es una libreria de componentes para Angular usando Material Design. Esta libreria lo que brinda es una coleccion de componentes listos para ser usados y configurados a nuestra eleccion.

## Instalacion

Para instalar angular material debemos ejecutar el siguiente comando dentro de la carpeta de la aplicacion:

```CMD
ng add @angular/material
```

El uso del comando `ng add` nos permitira instalar la libreria y que se actualice la aplicacion de forma automatica.

Este comando nos hara ciertas preguntas de como queremos que se configure la libreria, a continuacion encontraran que opciones seleccionar:

<p align="center">
<img src="./images/image-5.png">
</p>

<p align="center">
[Si queremos instalar Angular Material]
</p>

La siguiente pregunta es que paleta de colores queremos utilizar, esto es personal asi que pueden seleccionar cualquier opcion. La paleta de colores esta disponible en la documentacion de la libreria.

<p align="center">
<img src="./images/image-10.png">
</p>

<p align="center">
[Paleta de colores en la documentacion]
</p>

<p align="center">
<img src="./images/image-6.png">
</p>

<p align="center">
[Paleta de colores]
</p>

<p align="center">
<img src="./images/image-7.png">
</p>

<p align="center">
[Tipografia de Angular Material como global]
</p>

<p align="center">
<img src="./images/image-8.png">
</p>
<p align="center">
[Animaciones]
</p>

Una vez terminada la instalacion, se muestran los archivos modificados para incorporar Angular Material en la aplicacion.

<p align="center">
<img src="./images/image-9.png">
</p>

<p align="center">
[Actualizaciones automaticas]
</p>

## Modificando el componente button para usar angular material

Modificaremos este componente para que se vea como basico y raised segun la [documentacion](https://material.angular.io/components/button/examples).

<p align="center">
<img src="./images/image-11.png">
</p>

<p align="center">
[Boton angular material]
</p>

Para ello debemos modificar `button.component.html` de la siguiente manera:

```HTML
<button mat-raised-button [color]="color" (click)="onClick()">
  {{ title }}
</button>
```

El cual aplicara dichas clases al componente y su visualizacion debe ser la documentada en `angular material`.

Definamos un nuevo input al componente que sea `color` para dar la flexibilidad de cambiar el color de fondo del boton.

Dejando `button.component.ts` de la siguiente forma:

```TypeScript
@Component({
  selector: 'app-button',
  standalone: true,
  imports: [MatButtonModule],
  templateUrl: './button.component.html',
  styles: ``,
})
export class ButtonComponent {
  @Input({ required: true }) title!: string;
  @Input({ required: true }) onClick!: () => void;
  @Input() color: 'primary' | 'accent' | 'warn' = 'primary';
}
```

Como `Angular Material` es una libreria de componentes Angular, debemos crear nuestros componentes esqueletos y usar las directivas y componentes que la libreria provee y usarlos en los componentes de la aplicacion. Esto tiene como consecuencia la importacion de los elementos individuales necesarios como `MatButtonModule`.

Esto trae una desventaja la cual propone un tiempo de aprendizaje y de investigacion de como usar la libreria. No es muy intuitiva y requiere de cierta experiencia para poderla usar correctamente.

## Codigos

- [Componentes con `angular material`](https://github.com/daniel18acevedo/DA2-Tecnologia/tree/angular-style/1-%20Angular%20application/MyAngularMaterialApp)

## Lecturas Recomendadas

- [Angular Material](https://material.angular.io/)

