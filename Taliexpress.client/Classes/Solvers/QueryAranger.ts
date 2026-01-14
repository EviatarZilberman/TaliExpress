export class QueryAranger {
  public static Arange(map: Map<string, string>): string {
    let result: string = '';
    for (const [key, value] of map) {
      result += `${key}=${value}&`;
    }
    return result.slice(0, result.length - 1);
  }
}
