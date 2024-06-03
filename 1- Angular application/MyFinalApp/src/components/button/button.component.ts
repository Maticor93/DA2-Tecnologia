import { NgClass } from '@angular/common';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-button',
  standalone: true,
  imports: [NgClass],
  templateUrl: './button.component.html',
  styles: ``,
})
export class ButtonComponent {
  @Input({ required: true }) title!: string;
  @Input({ required: true }) onClick!: () => void;

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
