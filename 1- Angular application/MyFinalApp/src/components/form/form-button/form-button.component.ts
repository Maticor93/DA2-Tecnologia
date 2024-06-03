import { NgClass } from '@angular/common';
import { Component, Input } from "@angular/core";

@Component({
  selector: "app-form-button",
  standalone: true,
  imports: [NgClass],
  templateUrl: "./form-button.component.html",
  styles: ``,
})
export class FormButtonComponent {
  @Input({ required: true }) title!: string;
  @Input() color:
    | 'primary'
    | 'secondary'
    | 'success'
    | 'danger'
    | 'warning'
    | 'info'
    | 'light'
    | 'dark'
    | 'link' = 'dark';

  public colorClass(): string {
    return `btn-${this.color}`;
  }
}
