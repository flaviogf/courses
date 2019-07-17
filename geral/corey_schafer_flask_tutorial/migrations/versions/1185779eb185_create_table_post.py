"""create table post

Revision ID: 1185779eb185
Revises: 0f0c35429089
Create Date: 2019-07-17 10:45:14.669238

"""
from alembic import op
import sqlalchemy as sa
from datetime import datetime


# revision identifiers, used by Alembic.
revision = '1185779eb185'
down_revision = '0f0c35429089'
branch_labels = None
depends_on = None


def upgrade():
    op.create_table('post',
                    sa.Column('id',
                              sa.Integer,
                              primary_key=True),
                    sa.Column('title',
                              sa.String(100),
                              nullable=False),
                    sa.Column('date_posted',
                              sa.DateTime,
                              nullable=False,
                              default=datetime.utcnow),
                    sa.Column('content',
                              sa.Text,
                              nullable=False),
                    sa.Column('user_id',
                              sa.Integer,
                              sa.ForeignKey('user.id'),
                              nullable=False))


def downgrade():
    op.drop_table('post')
