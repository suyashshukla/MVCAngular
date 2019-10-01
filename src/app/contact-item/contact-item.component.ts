import { Component, Output, EventEmitter,Input } from '@angular/core';

@Component({
  selector: 'app-item',
  templateUrl: './contact-item.component.html',
  styleUrls: ['./contact-item.component.css']
})

export class ContactItem {
  @Input() details;

  @Output() display = new EventEmitter();

}
