import { Component, OnInit } from '@angular/core';
import { FormService} from './form-service';
import { Home } from './Home';
import { Router } from '@angular/router';

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

  constructor(private contactService: FormService,
    private router: Router) { }

  ngOnInit() {

    this.contactService.refreshDB.subscribe((event) => {
      this.fetchData();
    })

    this.fetchData();
  }

  fetchData() {
    this.contacts = [];
    this.contactService.fetchURL().subscribe((res: Home[]) => {
      this.contacts = res;
    });
  }

  addMockData() {

    this.contactService.getMock().subscribe((res: Home[]) => {

      var data = res.slice(0, 21);

      data.forEach(response => {
        this.contactService.postURL(response).subscribe((result) => {
          this.fetchData();
        })
      });
    });
  }

  deleteContacts() {
    this.contacts.forEach(contact => {
      this.contactService.deleteURL(contact).subscribe((response) => {
        this.fetchData();
      })
    })
  }

  editFormVisible() {
    this.formFlag = this.contactService.formVisibility;
  }

  closeForm() {
    this.formFlag = false;
    this.router.navigate(['']);
  }

  toggleForm() {
    this.router.navigate(['forms']);
  }

  display(contact) {
    this.contactService.getURL(contact.id).subscribe((res) => {
      this.infoContent = res;
    });
  }

  closeBox() {
    this.router.navigate(['']);
    this.fetchData();
  }

  updateList(query) {
    this.contactService.queryList(query.query).subscribe((response:Home[]) => {
      this.contacts = response;
    }
      )
  };

  routerLink(id) {

    this.router.navigate(['contact',id]);

  }

}
