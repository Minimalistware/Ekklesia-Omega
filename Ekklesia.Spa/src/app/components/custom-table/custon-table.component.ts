import { Component, Input, OnInit } from '@angular/core'
import { FaIconLibrary } from '@fortawesome/angular-fontawesome'
import { Column } from './Column'
import { faPen } from '@fortawesome/free-solid-svg-icons'

@Component({
  selector: 'app-custon-table',
  templateUrl: './custon-table.component.html',
  styleUrls: [],
})
export class CustonTableComponent implements OnInit {
  @Input() paginated: boolean = false
  @Input() expandable: boolean = false
  @Input() elements: any[] = []
  @Input() columns: Column[] = []
  @Input() loading: boolean = false
  @Input() emptyMessage: string = 'A pesquisa não retornou resultados.'
  @Input() paginateData: any
  @Input() filter: any
  @Input() customSearch: boolean = true
  @Input() currentPage: number

  constructor(private _library: FaIconLibrary) {
    this.currentPage = 1
    this._library.addIcons(faPen)
  }

  ngOnInit(): void {}

  public resolveField(obj: any, field: any): any {
    if (field == null || field.trim() === '') {
      return null
    }
    let fields = field.split('.')
    if (fields.length > 1) {
      const campo = fields[0]
      fields = fields.slice(1)
      if (obj[campo] != null) {
        return this.resolveField(obj[campo], fields.join('.'))
      }
    }
    if (typeof obj[field] === 'number') {
      return obj[field].toLocaleString()
    }
    if (typeof obj[field] === 'number') {
      return obj[field].toLocaleString()
    }

    return obj[field]
  }
}
