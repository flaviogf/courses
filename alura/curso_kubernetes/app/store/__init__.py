from datetime import datetime

from flask import Flask, jsonify

def create_app():
    app = Flask(__name__)

    @app.route('/')
    def index():
        return jsonify({'data': datetime.now().strftime('%Y-%m-%d %H:%M:%S')})

    return app
