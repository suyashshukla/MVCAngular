import { Component, OnInit } from '@angular/core';
import { FormService } from './form-service';
import { Home } from './Home';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';

  formFlag = false;

  header = "ADDRESS BOOK";
  
  infoContent: Home;

  contacts : Home[];

  constructor(private contactService: FormService) { }

  ngOnInit() {
    this.fetchData();


  }

  fetchData() {
    this.contactService.fetchURL().subscribe((res) => {
      this.contacts = res;
      this.infoContent = this.contactService.formData;
    });
  }

  editFormVisible() {
    this.formFlag = this.contactService.formVisibility;
  }

  closeForm() {
    this.formFlag = false;
  }

  toggleForm() {
    this.infoContent = new Home();
    this.formFlag = true;
  }

  display(contact) {
    this.contactService.getURL(contact.id).subscribe((res) => {
      this.infoContent = res;
    });
  }

  closeBox() {
    this.formFlag = false;
    this.fetchData();
  }

}
