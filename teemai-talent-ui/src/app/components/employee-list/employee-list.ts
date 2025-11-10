import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { EmployeeService, Employee } from '../../services/employee';

@Component({
  selector: 'app-employee-list',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './employee-list.html',
  styleUrls: ['./employee-list.css']
})
export class EmployeeListComponent implements OnInit {
  employees: Employee[] = [];
  searchTerm = '';
  selectedEmployee: Employee | null = null;
  isEditing = false;

  constructor(private employeeService: EmployeeService) {}
  ngOnInit(): void { this.loadEmployees(); }

  loadEmployees(): void {
    this.employeeService.getAll().subscribe({
      next: (data) => this.employees = data,
      error: (err) => console.error('Error loading employees:', err)
    });
  }

  onSearch(): void {
    if (this.searchTerm.trim()) {
      this.employeeService.search(this.searchTerm).subscribe({
        next: (data) => this.employees = data,
        error: (err) => console.error('Error searching:', err)
      });
    } else {
      this.loadEmployees();
    }
  }

  onEdit(employee: Employee): void {
    this.selectedEmployee = { ...employee };
    this.isEditing = true;
  }

  onDelete(id: number): void {
    if (confirm('Are you sure you want to delete this employee?')) {
      this.employeeService.delete(id).subscribe({
        next: () => this.loadEmployees(),
        error: (err) => console.error('Error deleting:', err)
      });
    }
  }

  onNew(): void {
    this.selectedEmployee = {
      id: 0,
      fullName: '',
      hireDate: new Date().toISOString().split('T')[0],
      position: '',
      salary: 0,
      department: ''
    };
    this.isEditing = true;
  }

  onSave(): void {
    if (!this.selectedEmployee) return;

    if (this.selectedEmployee.id === 0) {
      this.employeeService.create(this.selectedEmployee).subscribe({
        next: () => {
          this.loadEmployees();
          this.isEditing = false;
        },
        error: (err) => console.error('Error creating:', err)
      });
    } else {
      this.employeeService.update(this.selectedEmployee.id, this.selectedEmployee).subscribe({
        next: () => {
          this.loadEmployees();
          this.isEditing = false;
        },
        error: (err) => console.error('Error updating:', err)
      });
    }
  }

  onCancel(): void {
    this.isEditing = false;
    this.selectedEmployee = null;
  }
}