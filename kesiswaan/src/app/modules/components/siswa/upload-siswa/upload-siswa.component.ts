import { Component, OnDestroy, OnInit } from '@angular/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { SiswaListComponent } from '../siswa-list/siswa-list.component';
import { Router } from '@angular/router';

@Component({
    selector: 'app-upload-siswa',
    providers: [MessageService, ConfirmationService],
    templateUrl: './upload-siswa.component.html',
    styleUrl: './upload-siswa.component.scss'
})

export class UploadSiswaComponent implements OnInit, OnDestroy {
    URL: string = 'http://localhost:5000/api/v1/siswa/upload';

    visible: boolean = false;
  
    uploadFiles = [];

    constructor(private messageService: MessageService, private router: Router) {}

    ngOnInit(): void {
    }

    ngOnDestroy(): void {
      this.visible = false;
    }
    
    dialogUploadSiswa() {
        this.visible = true;
    }

    onUpload(event:any) {
        for (const file of event.files) {
            const createdDate = new Date()
            this.uploadFiles.push({file:file, createdDate:createdDate});
        }

        this.visible = false;
        this.router.navigate(['/siswa/list']);
    
        this.messageService.add({ severity: 'info', summary: 'Success', detail: 'File Uploaded' });
    }
}
