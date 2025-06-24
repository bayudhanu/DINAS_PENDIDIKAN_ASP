import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Kelas } from '../../api/kelas/kelas';

const baseUrl = 'http://localhost:5000/api/v1/kelas';
const httpOptions = {
  headers: new HttpHeaders(
    {
      'Content-Type': 'application/json',
    }
  ),
  params: new HttpParams()
};
const httpUploads = {
  headers: new HttpHeaders(
    {
      'accept': '*/*',
      'Content-Type': 'multipart/form-data',
    }
  ),
  params: new HttpParams()
}

@Injectable({
  providedIn: 'root'
})
export class KelasService {

  constructor(
    private http: HttpClient
  ) { }

  getPaginatedData(page: number, limit: number): Observable<any> {
    const params:HttpParams = new HttpParams()
      .set('page', page.toString())
      .set('limit', limit.toString());
    httpOptions.params = params;
    return this.http.post<any>(`${baseUrl}/list`, httpOptions);
  }

  get(id: number): Observable<Kelas> {
    return this.http.get<Kelas>(`${baseUrl}/${id}`);
  }

  getWaliKelas(): Observable<Kelas[]> {
    return this.http.get<Kelas[]>(`${baseUrl}/wali-kelas`);
  }

  getUnitSekolah(): Observable<Kelas[]> {
    return this.http.get<Kelas[]>(`${baseUrl}/unit-sekolah`);
  }

  create(data: Kelas): Observable<Kelas> {
    return this.http.post<Kelas>(baseUrl, data);
  }

  update(id: number, data: Kelas): Observable<Kelas> {
    return this.http.put<Kelas>(`${baseUrl}/${id}`, data);
  }

  delete(id: number): Observable<Kelas> {
    return this.http.delete<Kelas>(`${baseUrl}/${id}`);
  }

  deleteAll(): Observable<Kelas> {
    return this.http.delete<Kelas>(baseUrl);
  }

  getByNama(nama: string): Observable<Kelas[]> {
    return this.http.get<Kelas[]>(`${baseUrl}?nama=${nama}`);
  }

  upload(file:any){
    const params:HttpParams = new HttpParams()
    .set('file', file);
    httpUploads.params = params;
    return this.http.post<any>(`${baseUrl}/upload`, httpUploads);
  }

}
