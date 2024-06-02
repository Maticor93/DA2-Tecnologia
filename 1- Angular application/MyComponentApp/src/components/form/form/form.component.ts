import { Component, Input } from "@angular/core";
import { FormGroup, ReactiveFormsModule } from "@angular/forms";

@Component({
  selector: "app-form",
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: "./form.component.html",
  styles: ``,
})
export class FormComponent {
  @Input({ required: true }) form!: FormGroup;
  @Input({ required: true }) onSubmit!: (values: any) => void;

  public onLocalSubmit() {
    const isValid = this.form.valid;

    if (!isValid) {
      this.form.markAllAsTouched();
      return;
    }

    this.onSubmit(this.form.value);
  }
}
