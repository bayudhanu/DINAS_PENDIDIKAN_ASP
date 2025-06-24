import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-add-kelas',
    templateUrl: './add-kelas.component.html',
    styleUrl: './add-kelas.component.scss'
})

export class AddKelasComponent implements OnInit {
    visible: boolean = false;

    dropdownUnitSekolah: any[];
    selectedUnitSekolah: any;

    dropdownWaliKelas: any[];
    selectedWaliKelas: any;

    constructor(){}

    ngOnInit(): void {
        this.dropdownUnitSekolah = [
            { name: 'TK', code: '1' },
            { name: 'SD', code: '2' },
            { name: 'SMP', code: '3' },
            { name: 'SMA', code: '4' },
            { name: 'SMK', code: '5' },
        ];
        
        this.dropdownWaliKelas = [
            { name: 'Wali Kelas A', code: '1' },
            { name: 'Wali Kelas B', code: '2' },
        ];
    }

    dialogAddKelas() {
        this.visible = true;
    }
}
