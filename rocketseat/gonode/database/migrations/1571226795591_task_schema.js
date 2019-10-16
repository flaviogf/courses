'use strict'

/** @type {import('@adonisjs/lucid/src/Schema')} */
const Schema = use('Schema')

class TaskSchema extends Schema {
  up() {
    this.create('tasks', (table) => {
      table.increments()
      table
        .integer('project_id')
        .unsigned()
        .references('id')
        .inTable('projects')
      table
        .integer('user_id')
        .unsigned()
        .references('id')
        .inTable('users')
      table
        .integer('file_id')
        .unsigned()
        .references('id')
        .inTable('files')
      table.string('title', 255).notNullable()
      table.text('description').notNullable()
      table.timestamp('due_date').notNullable()
      table.timestamps()
    })
  }

  down() {
    this.drop('tasks')
  }
}

module.exports = TaskSchema
