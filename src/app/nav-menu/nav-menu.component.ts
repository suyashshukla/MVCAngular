import { Component, Output, EventEmitter, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {

  @Output() lightBox = new EventEmitter();
  @Output() homeScreen = new EventEmitter();
  @Output() mockData = new EventEmitter();
  @Output() deleteData = new EventEmitter();
  @Output() mockInput = new EventEmitter();

  inputFlag = false;

  header = "ADDRESS BOOK";
  length = this.header.length;
  
  index = 0;

  text = this.header;

  ngOnInit() {

    //setinterval(() => {
    //  this.text = this.text + this.header[this.index++];
    //  if (this.index == this.length)
    //    clearinterval(1);
    //}, 250);

  }



}
