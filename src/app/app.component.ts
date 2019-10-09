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

  header = "ADD BOOK";
  
  infoContent: Home;

  contacts : Home[];

  constructor(private contactService: FormService) { }

  ngOnInit() {
    this.fetchData();
  }

  fetchData() {
    this.contacts = [];
    this.contactService.fetchURL().subscribe((res: Home[]) => {
      this.contacts = res;
      this.infoContent = this.contactService.formData;
    });
  }

  addMockData() {
    this.contactService.getMock().subscribe((res: Home[]) => {

      var data = res.slice(0, 51);

      data.forEach(response => {
        this.contactService.postURL(response).subscribe((result) => {
          console.log(response.name + " Added");
          this.fetchData();
        })
      });
    });
  }

  deleteContacts() {
    this.contacts.forEach((contact) => {
      this.contactService.deleteURL(contact).subscribe((response) => {
        console.log(contact.name + " Deleted");
      })
    })
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
    this.ngOnInit();
  }

}
