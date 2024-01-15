import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { StoredEvent } from 'src/app/shared/models/stored-event';

import { environment } from 'src/environments/environment';

import { Vehicle } from '../models/vehicle';

@Injectable()
export class VehicleService {
    constructor(private http: HttpClient) { }

    public getAll(): Observable<Vehicle[]> {
        return this.http.get<Vehicle[]>(`${environment.apiUrl}/vehicles`);
    }

    public getById(id: string): Observable<Vehicle> {
        return this.http.get<Vehicle>(`${environment.apiUrl}/vehicles/${id}`);
    }

    public getHistory(id: string): Observable<StoredEvent[]> {
        return this.http.get<StoredEvent[]>(`${environment.apiUrl}/vehicles/history/${id}`);
    }

    public add(vehicle: Vehicle): Observable<any> {
        return this.http.post(`${environment.apiUrl}/vehicles`, vehicle);
    }

    public update(vehicle: Vehicle): Observable<any> {
        return this.http.put(`${environment.apiUrl}/vehicles`, vehicle);
    }

    public remove(id: string): Observable<any> {
        return this.http.delete(`${environment.apiUrl}/vehicles/${id}`);
    }
}