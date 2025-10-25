FROM node:22-alpine AS build

# Set working directory
WORKDIR /app

# Pass build args from GitHub Actions
ARG VITE_API_URL
ENV VITE_API_URL=$VITE_API_URL

# Copy project files
COPY package*.json ./
COPY index.html ./
COPY vite.config.js ./
COPY package*.json ./
COPY src ./src

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
