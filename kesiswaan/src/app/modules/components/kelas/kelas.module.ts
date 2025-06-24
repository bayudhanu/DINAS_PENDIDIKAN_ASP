import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TableModule } from 'primeng/table';
import { RatingModule } from 'primeng/rating';
import { SliderModule } from 'primeng/slider';
import { ToastModule } from 'primeng/toast';
import { ProgressBarModule } from 'primeng/progressbar';
import { DropdownModule } from 'primeng/dropdown';
import { MultiSelectModule } from 'primeng/multiselect';
import { RippleModule } from 'primeng/ripple';
import { ToggleButtonModule } from 'primeng/togglebutton';
import { InputTextModule } from 'primeng/inputtext';
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
import { InputGroupAddonModule } from 'primeng/inputgroupaddon';
import { InputGroupModule } from 'primeng/inputgroup';

import { KelasListComponent } from './kelas-list/kelas-list.component';
import { KelasDetailsComponent } from './kelas-details/kelas-details.component';
import { AddKelasComponent } from './add-kelas/add-kelas.component';
import { EditKelasComponent } from './edit-kelas/edit-kelas.component';
import { UploadKelasComponent } from './upload-kelas/upload-kelas.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SplitButtonModule } from 'primeng/splitbutton';

const routes: Routes = [
    { path: 'list', component: KelasListComponent },
    { path: 'show', component: KelasDetailsComponent },
    { path: 'add', component: AddKelasComponent },
    { path: 'edit', component: EditKelasComponent },
    { path: 'upload', component: UploadKelasComponent },
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
        ProgressBarModule,
        ToastModule,
        OverlayPanelModule,
        InputGroupModule,
        InputGroupAddonModule,
        SplitButtonModule,
        ChipsModule,
        HttpClientModule,
        RouterModule.forChild(routes),
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA],
    declarations: [
        KelasListComponent,
        KelasDetailsComponent,
        AddKelasComponent,
        EditKelasComponent,
        UploadKelasComponent,
    ],
    exports: [
        RouterModule,
        KelasListComponent,
        KelasDetailsComponent,
        AddKelasComponent,
        EditKelasComponent,
        UploadKelasComponent,
    ],
})
export class KelasModule {}
