import { Component, Output, EventEmitter, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {

  @Output() lightBox = new EventEmitter();
  @Output() homeScreen = new EventEmitter();

  header = "ADDRESS BOOK";
  length = this.header.length;
  
  index = 0;

  text = "";

  ngOnInit() {

    setInterval(() => {
      this.text = this.text + this.header[this.index++];
      if (this.index == this.length)
        clearInterval(1);
    }, 250);

  }

}
