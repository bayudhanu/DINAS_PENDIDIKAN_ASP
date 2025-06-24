import { Component, OnDestroy, OnInit } from '@angular/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { KelasListComponent } from '../kelas-list/kelas-list.component';
import { Router } from '@angular/router';

@Component({
    selector: 'app-upload-kelas',
    providers: [MessageService, ConfirmationService],
    templateUrl: './upload-kelas.component.html',
    styleUrl: './upload-kelas.component.scss',
})
export class UploadKelasComponent implements OnInit, OnDestroy {
    URL: string = 'http://localhost:5000/api/v1/kelas/upload';

    dropdownOptionButton: MenuItem[];
    kelasListComponent: KelasListComponent;

    isDialogOpen: boolean = false;
    uploadFiles = [];

    constructor(private messageService: MessageService, private router: Router) {}

    ngOnInit(): void {
        this.dropdownOptionButton = [
            {
                label: 'Upload Data Siswa',
                command: () => {
                    this.onOpenDialog();
                },
            },
            {
                label: 'Download Data Siswa',
                command: () => {},
            },
        ];
    }

    ngOnDestroy(): void {
        this.isDialogOpen = false;
    }

    onOpenDialog() {
        this.isDialogOpen = true;
    }

    onUpload(event: any) {
        for (const file of event.files) {
            const createdDate = new Date();
            this.uploadFiles.push({ file: file, createdDate: createdDate });
        }

        /**
         * router to kelas list
         */
        this.isDialogOpen = false;
        this.router.navigate(['/kelas/list']);

        this.messageService.add({
            severity: 'info',
            summary: 'Success',
            detail: 'File Uploaded',
        });
    }
}
