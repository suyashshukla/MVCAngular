import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { ContactItem } from './contact-item/contact-item.component';
import { ContactForm } from './contact-form/contact-form.component';
import { ContactInfo } from './contact-info/contact-info.component';

import { FormService } from './form-service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    ContactItem,
    ContactForm,
    ContactInfo
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
  ],
  providers: [FormService],
  bootstrap: [AppComponent]
})
export class AppModule { }
