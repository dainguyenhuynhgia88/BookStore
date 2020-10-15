export interface Book {
  id: number;
  imageUrl: string;
  title: string;
  authors: Array<string>;
  publishedDate: Date,
  description: string
}
