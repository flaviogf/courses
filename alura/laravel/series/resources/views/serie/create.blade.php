@extends('layouts.app')

@section('content')
    <div class="row justify-content-center my-2">
        <div class="col col-12 col-md-8 col-lg-6">
            <form method="POST" action="{{ route('serie.store') }}">
                @csrf

                <div class="form-group">
                    <label for="name">Name:</label>
                    <input class="form-control" name="name" id="name" type="text" />
                </div>

                <button class="btn btn-dark" type="submit">Save</button>
            </form>
        </div>
    </div>
@endsection
