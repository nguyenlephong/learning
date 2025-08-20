import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.html'
})
export class UserFormComponent {
  userForm: FormGroup;
  isSubmitting = false;

  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.userForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]]
    });
  }

  onSubmit() {
    if (this.userForm.invalid) return;

    this.isSubmitting = true;
    this.http.post('https://jsonplaceholder.typicode.com/users', this.userForm.value)
      .subscribe({
        next: (res) => {
          console.log('✅ Submitted:', res);
          this.isSubmitting = false;
          this.userForm.reset();
        },
        error: (err) => {
          console.error('❌ Error:', err);
          this.isSubmitting = false;
        }
      });
  }
}
