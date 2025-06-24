import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';

interface UploadEvent {
    originalEvent: Event;
    files: File[];
}

@Component({
    selector: 'app-add-siswa',
    templateUrl: './add-siswa.component.html',
    styleUrl: './add-siswa.component.scss',
    providers: [MessageService]
})

export class AddSiswaComponent implements OnInit {
    visible: boolean = false;

    dropdownJenisKelamin: any[];
    selectedJenisKelamin: any;

    dropdownAgama: any[];
    selectedAgama: any;

    dropdownJenjangPendidikan: any[];
    selectedJenjangPendidikan: any;

    dropdownUnitSekolah: any[];
    selectedUnitSekolah: any;

    dropdownKelas: any[];
    selectedKelas: any;

    dropdownRombelSaatIni: any[];
    selectedRombelSaatIni: any;

    password!: string;
    konfirmasiPassword!: string;

    selectedStatus: any = null;
    statusSiswa: any[] = [
        { name: 'Aktif', key: '1' },
        { name: 'Tidak Aktif', key: '2' },
        { name: 'Tamat', key: '3' },
        { name: 'Pindah Sekolah', key: '4' },
        { name: 'Drop Out', key: '5' }
    ];
    
    uploadedFiles: any[] = [];

    constructor(private messageService: MessageService) {}
    
    ngOnInit(): void {
        this.dropdownJenisKelamin = [
            { name: 'Laki-laki', code: 'L' },
            { name: 'Perempuan', code: 'P' }
        ];
        
        this.dropdownAgama = [
            { name: 'Islam', code: '1' },
            { name: 'Kristen', code: '2' },
            { name: 'Protestan', code: '3' },
            { name: 'Hindu', code: '4' },
            { name: 'Budha', code: '5' },
            { name: 'Konghuchu', code: '6' },
        ];

        this.dropdownJenjangPendidikan = [
            { name: 'Tidak Sekolah', code: '1' },
            { name: 'SD', code: '2' },
            { name: 'SMP', code: '3' },
            { name: 'SMA', code: '4' },
            { name: 'SMK', code: '5' },
            { name: 'D1', code: '6' },
            { name: 'D2', code: '7' },
            { name: 'D3', code: '8' },
            { name: 'D4', code: '9' },
            { name: 'S1', code: '10' },
            { name: 'S2', code: '11' },
            { name: 'S3', code: '12' },
        ];

        this.dropdownUnitSekolah = [
            { name: 'TK', code: '1' },
            { name: 'SD', code: '2' },
            { name: 'SMP', code: '3' },
            { name: 'SMA', code: '4' },
            { name: 'SMK', code: '5' },
        ];

        this.dropdownKelas = [
            { name: '1 A', code: '1' },
            { name: '1 B', code: '2' },
        ];

        this.dropdownRombelSaatIni = [
            { name: 'Rombel 1', code: '1' },
            { name: 'Rombel 2', code: '2' },
        ];

        this.selectedStatus = this.statusSiswa[0];
    }

    dialogAddSiswa() {
        this.visible = true;
    }

    onUpload(event:any) {
        for(let file of event.files) {
            this.uploadedFiles.push(file);
        }

        this.messageService.add({severity: 'info', summary: 'File Uploaded', detail: ''});
    }
}
