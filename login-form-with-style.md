[Atras - Indice](https://github.com/daniel18acevedo/DA2-Tecnologia/tree/angular-style)

# Aplicando estilos a `login-form`

En esta seccion aplicaremos estilos a los elementos necesarios de `login-form`. Centraremos el titulo y el formulario a la pagina, definiremos espacios entre los elementos, alinearemos de forma vertical el formulario, definiremos una `card` y otros estilos. Tambien definiremos un componente `navbar` para usar en `home` con estilos tambien.

Pasaremos a modificar el template HTML de `login-form` para alinear de forma vertical los elementos:

```HTML
<!-- ... -->

<app-form [form]="loginForm" (onSubmit)="onSubmit($event)">
  <div class="mb-3">
    <app-form-input
      type="text"
      placeholder="email@example.com"
      [name]="formField.email.name"
      [form]="loginForm"
      [formField]="formField" />
  </div>

  <div class="mb-4">
    <app-form-input
      type="password"
      placeholder="*****"
      [name]="formField.password.name"
      [form]="loginForm"
      [formField]="formField" />
  </div>

<!-- ... -->
</app-form>
```

## Codigos

- [MyFinalApp](https://github.com/daniel18acevedo/DA2-Tecnologia/tree/angular-style/1-%20Angular%20application/MyFinalApp)

