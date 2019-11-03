<?php

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
*/

Route::get('/', 'SerieController@index')->name('serie.index');
Route::get('serie/create', 'SerieController@create')->name('serie.create');
Route::post('serie', 'SerieController@store')->name('serie.store');
