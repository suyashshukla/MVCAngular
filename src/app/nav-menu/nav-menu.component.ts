import { Component, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  @Output() lightBox = new EventEmitter();
  @Output() homeScreen = new EventEmitter();

  hit() {
    window.alert("hello   ");
  }


}
