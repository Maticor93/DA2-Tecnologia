import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-input',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './input.component.html',
  styles: ``,
})
export class InputComponent {
  @Input() label: string | null = null;
  @Input() placeholder = '';
  @Input() type: 'text' | 'number' = 'text';
  @Input() value = '';

  @Output() valueChange = new EventEmitter<string>();

  public onValueChange(event: any): void {
    this.valueChange.emit(event.target.value);
  }
}
