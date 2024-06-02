import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

export const authGuard: CanActivateFn = (route, state) => {
  const isLoggedIn = localStorage.getItem('isLoggedIn') !== null;

  if (!isLoggedIn) {
    const router = inject(Router);

    return router.parseUrl('/login');
  }

  return true;
};
