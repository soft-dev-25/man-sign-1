FROM node:18-alpine AS build

# Set working directory
WORKDIR /app

# Copy project files
COPY . .

# Install dependencies and build the project
RUN npm install --ignore-scripts && npm run build

# Use nginx to serve static files
FROM nginx:alpine

# Copy static files to nginx html directory
COPY --from=build /app/dist /usr/share/nginx/html

# Expose port 80
EXPOSE 80

# Start nginx
CMD ["nginx", "-g", "daemon off;"]
