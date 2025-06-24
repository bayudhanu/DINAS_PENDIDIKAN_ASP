import { CUSTOM_ELEMENTS_SCHEMA, input, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TableCheckbox, TableModule } from 'primeng/table';
import { RatingModule } from 'primeng/rating';
import { SliderModule } from 'primeng/slider';
import { ToastModule } from 'primeng/toast';
import { ProgressBarModule } from 'primeng/progressbar';
import { DropdownModule } from 'primeng/dropdown';
import { MultiSelectModule } from 'primeng/multiselect';
import { RippleModule } from 'primeng/ripple';
import { ToggleButtonModule } from 'primeng/togglebutton';
import { InputText, InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { RouterModule, Routes } from '@angular/router';
import { PaginatorModule } from 'primeng/paginator';
import { BreadcrumbModule } from 'primeng/breadcrumb';
import { FileUploadModule } from 'primeng/fileupload';
import { DialogModule } from 'primeng/dialog';
import { BadgeModule } from 'primeng/badge';
import { HttpClientModule } from '@angular/common/http';
import { OverlayPanelModule } from 'primeng/overlaypanel';
import { ChipsModule } from 'primeng/chips';
import { InputGroupAddon, InputGroupAddonModule } from 'primeng/inputgroupaddon';
import { InputGroupModule } from 'primeng/inputgroup';
import { InputTextarea, InputTextareaModule } from 'primeng/inputtextarea';
import { TabViewModule } from 'primeng/tabview';
import { SplitButtonModule } from 'primeng/splitbutton';
import { PasswordModule } from 'primeng/password';
import { RadioButtonModule } from 'primeng/radiobutton';

import { SiswaListComponent } from './siswa-list/siswa-list.component';
import { SiswaDetailsComponent } from './siswa-details/siswa-details.component';
import { AddSiswaComponent } from './add-siswa/add-siswa.component';
import { EditSiswaComponent } from './edit-siswa/edit-siswa.component';
import { UploadSiswaComponent } from './upload-siswa/upload-siswa.component';

const routes: Routes = [
    { path: 'list', component: SiswaListComponent },
    { path: 'show', component: SiswaDetailsComponent },
    { path: 'add', component: AddSiswaComponent },
    { path: 'edit', component: EditSiswaComponent },
    { path: 'upload', component: UploadSiswaComponent }
];

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        BreadcrumbModule,
        TableModule,
        PaginatorModule,
        RatingModule,
        ButtonModule,
        SliderModule,
        InputTextModule,
        ToggleButtonModule,
        RippleModule,
        MultiSelectModule,
        DropdownModule,
        ProgressBarModule,
        ToastModule,
        FileUploadModule,
        DialogModule,
        BadgeModule,
        OverlayPanelModule,
        InputGroupModule,
        InputGroupAddonModule,
        ChipsModule,
        HttpClientModule,
        InputTextareaModule,
        TabViewModule,
        SplitButtonModule,
        PasswordModule,
        RadioButtonModule,
        RouterModule.forChild(routes),
    ],
    schemas:[CUSTOM_ELEMENTS_SCHEMA],
    declarations: [
        SiswaListComponent,
        SiswaDetailsComponent,
        AddSiswaComponent,
        EditSiswaComponent,
        UploadSiswaComponent
    ],
    exports: [RouterModule]
})
export class SiswaModule { }
