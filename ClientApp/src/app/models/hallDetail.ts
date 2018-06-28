import { NameIdPair } from './nameIdPair';

export interface HallDetail {
  hallDetailId: number;
  hallName: string;
  hallCapacity: number;
  hallOwner: NameIdPair;
}
