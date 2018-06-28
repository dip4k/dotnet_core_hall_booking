import { User } from './user';

export interface Customer {
  customerId: number;
  name: string;
  email: string;
  address: string;
  aadharNo: string;
  user: User;
}
