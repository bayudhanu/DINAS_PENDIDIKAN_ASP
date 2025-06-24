import { NgModule } from '@angular/core';
import { CommonModule, HashLocationStrategy, LocationStrategy, PathLocationStrategy } from '@angular/common';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { AppLayoutModule } from './layout/app.layout.module';
import { NotfoundComponent } from './modules/components/notfound/notfound.component';
import { ProductService } from './modules/services/product.service';
import { CountryService } from './modules/services/country.service';
import { CustomerService } from './modules/services/customer.service';
import { EventService } from './modules/services/event.service';
import { IconService } from './modules/services/icon.service';
import { NodeService } from './modules/services/node.service';
import { PhotoService } from './modules/services/photo.service';
import { BrowserAnimationsModule, provideAnimations } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
    declarations: [AppComponent, NotfoundComponent],
    imports: [
        CommonModule,
        BrowserModule, 
        BrowserAnimationsModule, 
        FormsModule,
        ReactiveFormsModule,
        RouterModule,
        AppRoutingModule, 
        AppLayoutModule, 
        HttpClientModule
    ],
    providers: [
        { provide: LocationStrategy, useClass: PathLocationStrategy },
        CountryService, 
        CustomerService, 
        EventService, 
        IconService, 
        NodeService,
        PhotoService, 
        ProductService, 
        provideAnimations()
    ],
    bootstrap: [AppComponent],
})
export class AppModule {}
